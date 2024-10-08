﻿using AutoMapper;
using BeautyStore.Application.User;
using BeautyStore.Domain.Interfaces;
using MediatR;

namespace BeautyStore.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly IMapper _mapper;
        private readonly IUserSession _userSession;
        private readonly IProductRepository _productRepository;
        private readonly IProductImagesRepository _productImagesRepository;

        public CreateProductCommandHandler(IMapper mapper, IUserSession userSession, IProductRepository productRepository, IProductImagesRepository productImagesRepository)
        {
            _mapper = mapper;
            _userSession = userSession;
            _productRepository = productRepository;
            _productImagesRepository = productImagesRepository;
        }

        public async Task<Unit> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = _mapper.Map<Domain.Entities.Product>(request);
            var user = _userSession.GetSession();

            if (user == null)
            {
                throw new UnauthorizedAccessException();
            }

            product.CreatedByUserId = user.Id;
            var images = request.Images;

            await _productRepository.CreateProductAsync(product);

            if (images != null)
            {
                var imagesList = images.Split(';');
                await _productImagesRepository.CreateProductImagesAsync(product.Id, imagesList);
            }

            return Unit.Value;
        }
    }
}
