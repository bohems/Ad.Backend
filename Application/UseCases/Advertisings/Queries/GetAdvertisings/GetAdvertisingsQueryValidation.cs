﻿using FluentValidation;

namespace Application.UseCases.Advertisings.Queries.GetAdvertisings
{
    public class GetAdvertisingsQueryValidation : AbstractValidator<GetAdvertisingsQuery>
    {
        public GetAdvertisingsQueryValidation()
        {
            RuleFor(getAdvertisingsQuery =>
                getAdvertisingsQuery.UserId).NotEqual(Guid.Empty);
        }
    }
}