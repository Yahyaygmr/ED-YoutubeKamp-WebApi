using Business.Abstracts;
using Business.Dtos.Requests;
using Business.Dtos.Responses;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class BrandManager : IBrandService
    {
        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public CreatedBrandResponse Add(CreateBrandRequest createBrandRequest)
        {
            //Business Rules

            //mapping
            Brand brand = new();
            brand.Name = createBrandRequest.Name;
            _brandDal.Add(brand);

            //mapping
            CreatedBrandResponse createBrandResponse = new CreatedBrandResponse();
            createBrandResponse.Name = brand.Name;
            createBrandResponse.Id = 6;
            createBrandResponse.CreatedDate = brand.CreatedDate;

            return createBrandResponse;
        }

        public List<GetAllBrandResponse> GetAll()
        {
            List<Brand> brands = _brandDal.GetAll();

            List<GetAllBrandResponse> getAllBrandResponses = new List<GetAllBrandResponse>();

            foreach (var item in brands)
            {
                GetAllBrandResponse getAllBrandResponse = new GetAllBrandResponse();
                getAllBrandResponse.Name = item.Name;
                getAllBrandResponse.Id = item.Id;
                getAllBrandResponse.CreatedDate = item.CreatedDate;

                getAllBrandResponses.Add(getAllBrandResponse);
            }
            return getAllBrandResponses;
        }
    }
}
