namespace Domain.Entities
{
    public class Vendedor
    {
        public string CPF { get; set; }
        public string Name { get; set; }
        public decimal? Salary { get; set; }

        public Vendedor(string[] arrlinha)
        {
            CPF = arrlinha[1];
            Name = arrlinha[2];
            Salary = string.IsNullOrEmpty(arrlinha[3]) ? 0 : decimal.Parse(arrlinha[3].Replace(".", ","));
        }

        public Vendedor(string cpf, string name, decimal? salary)
        {
            CPF = cpf;
            Name = name;
            Salary = salary;
        }
    }
}
