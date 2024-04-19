namespace JDPodrozeAPI.Services.Orders
{
    public static class OrdersEmailsTemplates
    {
        public static string GetConfirmationOfReceivedPayment(string excursionName, decimal amount)
        {
            string body = $@"
                <html>
                    <head>
                        <style>
                            .email-container {{
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 32px 0;
                                font-family: Arial, sans-serif;
                                width: 100%;
                              }}
  
                              .email-container img {{
                                display: block;
                                width: 200px;
                                height: 50px;
                                margin: 0 auto;
                              }}
  
                              .email-container h2 {{
                                width: 100%;
                                text-align: center;
                              }}
      
                              .email-container h3 {{
                                font-weight: 400;
                                font-size: 16px;
                              }}
  
                              .email-container span {{
                                font-size: 16px;
                              }}
                        </style>
                    </head>
                    <body>
                        <div class='email-container'>
                            <img src='cid:logo' alt='logo'>
                            <hr>
                            <h2>Potwierdzenie otrzymania wpłaty</h2>
                            <hr>
                            <h3>Dzień dobry,</h3>
                            <span>Pragniemy poinformować, że otrzymaliśmy Państwa wpłatę dotyczącą rezerwacji wycieczki <b>{excursionName}</b> w wysokości <b>{amount}</b> PLN.
                                <br>Dziękujemy za dokonanie opłaty w ustalonym terminie.
                                <br><br>Rezerwacja wycieczki jest teraz potwierdzona.
                                <br><br>Szczegółowe informacje dotyczące wyjazdu zostaną przesłane w osobnej wiadomości.
                                <br><br>Dziękujemy za wybór naszej firmy i życzymy niezapomnianych wrażeń podczas nadchodzącej podróży.
                                <br><br>Z wyrazami szacunku,
                                <br>JD Podróże
                            </span>
                        </div>
                    </body>
                </html>";
            return body;
        }

        public static string GetOrderConfirmationOfBookingSubmissionTraditionalTransfer(string excursionName, string surname, decimal amount)
        {
            string body = $@"
                <html>
                    <head>
                        <style>
                            .email-container {{
                                max-width: 600px;
                                margin: 0 auto;
                                padding: 32px 0;
                                font-family: Arial, sans-serif;
                                width: 100%;
                              }}
  
                              .email-container img {{
                                display: block;
                                width: 200px;
                                height: 50px;
                                margin: 0 auto;
                              }}
  
                              .email-container h2 {{
                                width: 100%;
                                text-align: center;
                              }}
      
                              .email-container h3 {{
                                font-weight: 400;
                                font-size: 16px;
                              }}
  
                              .email-container span {{
                                font-size: 16px;
                              }}
                        </style>
                    </head>
                    <body>
                        <div class='email-container'>
                            <img src='cid:logo' alt='logo'>
                            <hr>
                            <h2>Potwierdzenie złożenia rezerwacji</h2>
                            <hr>
                            <h3>Dzień dobry,</h3>
                            <span>Złożono rezerwację wycieczki <b>{excursionName}</b> na nazwisko <b>{surname}</b>.
                                <br><br>
                                Prosimy o dokonanie wpłaty w wysokości <b>{amount}</b> PLN na poniższy numer konta.
                                <br>ING Bank Śląski <b>75 1050 1621 1000 0097 8972 9952</b>
                                <br><br>
                                W tytule przelewu proszę wpisać nazwę wycieczki tj <b>{excursionName}</b>.
                                <br>Jeżeli dane osoby dokonującej przelewu różnią się od danych osoby rezerwującej, prosimy o wpisanie w tytule przelewu imienia i nazwiska osoby rezerwującej. Umożliwi to prawidłowe przypisanie płatności.
                                <br><br>Dziękujemy za wybór naszej oferty! Mamy nadzieję, że wycieczka będzie niezapomniana i świetnie się Państwo będą bawić.
                                <br><br>Pozdrawiamy,
                                <br>JD Podróże
                            </span
                        </div>
                    </body>
                </html>";
            return body;
        }
    }
}