namespace Produkter.Mapping
{
    public class ProduktMapping : AutoMapper.Profile
    {
        public ProduktMapping()
        {
            CreateMap<Db.Produkt, Models.Produkt>();
            CreateMap<Models.Produkt, Db.Produkt>();
        }
    }
}