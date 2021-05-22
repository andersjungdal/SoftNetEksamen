namespace Kategorier.Mapping
{
    public class KategoriMapping : AutoMapper.Profile
    {
        public KategoriMapping()
        {
            CreateMap<Db.Kategori, Models.Kategori>();
            CreateMap<Models.Kategori, Db.Kategori>();
        }
    }
}