using Azure.Core;
using JDPodrozeAPI.Core.Contexts.Excursions;
using JDPodrozeAPI.Core.DTOs;
using JDPodrozeAPI.Core.DTOs.Excursions;
using JDPodrozeAPI.Core.Enums;
using JDPodrozeAPI.Services.Orders.Enums;
using Microsoft.EntityFrameworkCore;

namespace JDPodrozeAPI.Core.Repositories
{
    public class OrdersRepository : BaseRepository<ExcursionsDbContext>, IOrdersRepository
    {
        public OrdersRepository(ExcursionsDbContext context) : base(context)
        {

        }

        public Task<List<ExcursionDTO>> GetList(OrdersListFilterActiveType active)
        {
            IQueryable<ExcursionDTO> listQuery = _context.Excursions
                .Include(x => x.Orders)
                .ThenInclude(x => x.Participants)
                .Include(x => x.PickupPoints)
                .Where(x => x.Orders.Any());

            switch (active)
            {
                case OrdersListFilterActiveType.ACTIVE:
                    listQuery = listQuery.Where(x => x.Active);
                    break;
                case OrdersListFilterActiveType.INACTIVE:
                    listQuery = listQuery.Where(x => !x.Active);
                    break;
                case OrdersListFilterActiveType.ARCHIVED:
                    listQuery = listQuery.Where(x => !x.Active || (x.DateFrom == null || x.DateFrom < DateTime.Now));
                    break;
            }

            return listQuery
                .OrderBy(x => x.DateFrom)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ExcursionDTO> GetExcursionWithOrders(int excursionId)
        {
            ExcursionDTO excursion = await _context.Excursions
               .Include(x => x.Orders)
               .ThenInclude(x => x.Participants)
               .Include(x => x.PickupPoints)
               .AsNoTracking()
               .SingleAsync(x => x.Id == excursionId);

            excursion.Orders = excursion.Orders
                .OrderByDescending(x => x.BookerId)
                .Select(order =>
                {
                    order.Participants = order.Participants
                        .OrderBy(x => x.BookerId != null)
                        .ThenBy(x => $"{x.Name} {x.Surname}")
                        .ToList();
                    return order;
                })
                .ToList();

            return excursion;
        }

        public async Task<ExcursionOrderDTO> ChangePaymentStatus(Guid orderId, PaymentStatus status)
        {
            ExcursionOrderDTO order = await _context.ExcursionsOrders
                .Include(x => x.Participants)
                .Include(x => x.Excursion)
                .SingleAsync(x => x.OrderId == orderId);

            order.PaymentStatus = (char) status;
            _context.ExcursionsOrders.Update(order);
            await _context.SaveChangesAsync();
            return order;
        }

        public async Task<Task<int>> AddOrEditParticipant(int? participantId, Guid orderId, ExcursionParticipantDTO participant)
        {
            ExcursionOrderDTO excursionOrder = await _context.ExcursionsOrders
               .Include(x => x.Excursion)
               .Include(x => x.Participants)
                .AsNoTracking()
               .SingleAsync(x => x.OrderId == orderId);

            if (participantId == null)
                _context.ExcursionsParticipants.Add(participant);
            else
                _context.ExcursionsParticipants.Update(participant);

            _SumOrderPrice(excursionOrder, excursionOrder.Participants);
            return _context.SaveChangesAsync();
        }

        public async Task<Task<int>> DeleteParticipant(int participantId)
        {
            ExcursionParticipantDTO excursionParticipant = await _context.ExcursionsParticipants
                .Include(x => x.Order)
                .Include(x => x.Order.Excursion)
                .Include(x => x.Order.Participants)
                .SingleAsync(x => x.Id == participantId);

            if (excursionParticipant.BookerId == null)
            {
                _context.ExcursionsParticipants.RemoveRange(excursionParticipant.Order.Participants);
                _context.ExcursionsOrders.Remove(excursionParticipant.Order);
            }
            else
            {
                List<ExcursionParticipantDTO> participantsExceptCurrent = excursionParticipant.Order.Participants
                    .Where(x => x.Id != excursionParticipant.Id)
                    .ToList();

                _SumOrderPrice(excursionParticipant.Order, participantsExceptCurrent);

                _context.ExcursionsOrders.Update(excursionParticipant.Order);
                _context.ExcursionsParticipants.Remove(excursionParticipant);
            }
            return _context.SaveChangesAsync();
        }

        public async Task<bool> SetPickupPoint(Guid orderId, Guid pickupPointId)
        {
            ExcursionOrderDTO? order = await _context.ExcursionsOrders
                .SingleOrDefaultAsync(x => x.OrderId == orderId);

            if (order is null)
                return false;

            ExcursionPickupPointDTO? pickupPoint = await _context.ExcursionsPickupPoints
                .AsNoTracking()
                .SingleOrDefaultAsync(x => x.Id == pickupPointId);
        
            if (pickupPoint is null)
                return false;

            order.PickupPointId = pickupPointId;
            await _context.SaveChangesAsync();
            return true;
        }

        private void _SumOrderPrice(ExcursionOrderDTO order, List<ExcursionParticipantDTO> participants)
        {
            order.Price = participants
                .Sum(x => x.Discount ? order.Excursion.DiscountPriceGross : order.Excursion.PriceGross);
        }
    }
}