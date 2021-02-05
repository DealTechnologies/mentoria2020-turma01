using Flunt.Notifications;
using System.Text.RegularExpressions;

namespace Votacao.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        public string Valor { get; private set; }

        public Email(string valor)
        {
            Valor = valor;

            if (!Validar(Valor))
                AddNotification("Email", "Email inválido");
        }

        public bool Validar(string email) => Regex.IsMatch(email, @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

        public override string ToString() => this.Valor;
    }
}