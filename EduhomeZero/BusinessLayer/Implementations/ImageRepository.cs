using BusinessLayer.Services;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Implementations
{
    public class ImageRepository : IImageService
    {
        private readonly IImageDal _imageRepository;

        public ImageRepository(IImageDal imageRepository)
        {
            _imageRepository = imageRepository;
        }

        public async Task<Image> Get(int id)
        {
            Image image = await _imageRepository.GetAsync(n => n.Id == id);

            if(image is null)
            {
                throw new NullReferenceException();
            }

            return image;
        }

        public async Task Create(Image entity)
        {
            if(entity is null)
            {
                throw new ArgumentNullException();
            }

            await _imageRepository.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            Image image = await Get(id);

            if(image is null)
            {
                throw new NullReferenceException();
            }

            await _imageRepository.DeleteAsync(image);
        }

        

        public Task<List<Image>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Task Update(Image entity)
        {
            throw new System.NotImplementedException();
        }
    }
}
