using Core.EFRepository.EFEntityRepository;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class ImageRepositoryDal : EFEntityRepositoryBase<Image, AppDbContext> ,IImageDal
    {
        public ImageRepositoryDal(AppDbContext context) : base(context) {}
    }
}
