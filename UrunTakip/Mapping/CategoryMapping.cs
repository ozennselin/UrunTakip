using UrunTakip.Data;
using UrunTakip.Data.Entities;
using UrunTakip.DTO.CategoryDTOS;

namespace UrunTakip.Mapping
{
    public class CategoryMapping
    {
        NorthwindDB _db;
        
        public CategoryMapping(NorthwindDB db)
        {
            _db = db;
        }

        public CategoryListDto ListMapping(Categories category)
        {
            CategoryListDto dto= new CategoryListDto();
            dto.CategoryId = category.CategoryId;
            dto.CategoryName = category.CategoryName;
            dto.Description = category.Description;

            return dto;
        }

        public Categories InsertMapping (CategoryInsertDto dto)
        {
            Categories category = new Categories();
            category.CategoryName = dto.CategoryName;
            category.Description = dto.Description;

            return category;
        }

        public Categories UpdateMapping (CategoryUpdateDto dto)
        {
            Categories category = _db.Categories.Find(dto.CategoryId);
            category.CategoryName=dto.CategoryName;
            category.Description = dto.Description;

            return category;
        }
    }
}
