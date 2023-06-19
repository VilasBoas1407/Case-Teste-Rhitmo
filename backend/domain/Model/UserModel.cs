﻿using Api.Domain.Enum;

namespace Api.Domain.Model
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
        public string State { get; set; }
        public string Adress { get; set; }
        public string CEP { get; set; }
        public string City { get; set; }
        public PaymentType PaymentType { get; set; }
        public string CardName { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExperirationData{ get; set; }
        public string SafeCode { get; set; }

    }
}
