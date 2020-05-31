namespace Domain.Entities
{
    public class Cliente
    {
        public string CNPJ { get; set; }
        public string Name { get; set; }
        public string BusinessArea { get; set; }

        public Cliente(string[] arrlinha)
        {
            CNPJ = arrlinha[1];
            Name = arrlinha[2];
            BusinessArea = arrlinha[3];
        }

        public Cliente(string cnpj, string name, string businessArea)
        {
            CNPJ = cnpj;
            Name = name;
            BusinessArea = businessArea;
        }
    }
}
