using Core.EFRepository.EFEntityRepository;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Data;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Implementations
{
    public class SliderRepositoryDal : EFEntityRepositoryBase<Slider, AppDbContext>, ISliderDal
    {
        public SliderRepositoryDal(AppDbContext context) : base(context) {}
    }
}
