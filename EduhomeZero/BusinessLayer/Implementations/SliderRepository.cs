using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class SliderRepository : ISliderService
    {
        private readonly ISliderDal _sliderRepository;

        public SliderRepository(ISliderDal sliderRepository)
        {
            _sliderRepository = sliderRepository;
        }

        public async Task<Slider> Get(int id)
        {
            Slider slider = await _sliderRepository.GetAsync(n => !n.IsDeleted && n.Id == id);

            if(slider is null)
            {
                throw new NullReferenceException();
            }

            return slider;
        }

        public async Task<List<Slider>> GetAll()
        {
            List<Slider> sliders = await _sliderRepository.GetAllAsync(n => !n.IsDeleted);

            if(sliders is null)
            {
                throw new NullReferenceException();
            }

            return sliders;
        }

        public async Task Create(Slider entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.CreatedDate = DateTime.Now;
            entity.IsDeleted = false;

            await _sliderRepository.AddAsync(entity);
        }

        public async Task Update(Slider entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            entity.UpdatedDate = DateTime.Now;

            await _sliderRepository.UpdateAsync(entity);
        }

        public async Task Delete(int id)
        {
            Slider slider = await Get(id);

            if (slider is null)
            {
                throw new NullReferenceException();
            }

            await _sliderRepository.DeleteAsync(slider);
        }
    }
}
