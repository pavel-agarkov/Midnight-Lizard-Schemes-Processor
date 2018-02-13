﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MidnightLizard.Schemes.Domain.PublicSchemeAggregate
{
    public class ColorSchemeValidator : AbstractValidator<ColorScheme>
    {
        public ColorSchemeValidator()
        {
            RuleFor(cs => cs.colorSchemeId).NotEmpty().Length(1, 50);
            RuleFor(cs => cs.colorSchemeName).NotEmpty().Length(1, 50);

            RuleFor(cs => cs.scheduleFinishHour).InclusiveBetween(0, 24);
            RuleFor(cs => cs.scheduleStartHour).InclusiveBetween(0, 24);

            RuleFor(cs => cs.blueFilter).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundGraySaturation).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundGrayHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.textSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.textContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.textLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.textGraySaturation).InclusiveBetween(0, 100);
            RuleFor(cs => cs.textGrayHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.textSelectionHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.linkSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.linkContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.linkLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.linkDefaultSaturation).InclusiveBetween(0, 100);
            RuleFor(cs => cs.linkDefaultHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.linkVisitedHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.borderSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.borderContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.borderLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.borderGraySaturation).InclusiveBetween(0, 100);
            RuleFor(cs => cs.borderGrayHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.imageLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.imageSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundImageLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.backgroundImageSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.scrollbarSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.scrollbarContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.scrollbarLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.scrollbarGrayHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.buttonSaturationLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.buttonContrast).InclusiveBetween(0, 100);
            RuleFor(cs => cs.buttonLightnessLimit).InclusiveBetween(0, 100);
            RuleFor(cs => cs.buttonGraySaturation).InclusiveBetween(0, 100);
            RuleFor(cs => cs.buttonGrayHue).InclusiveBetween(0, 359);
            RuleFor(cs => cs.scrollbarSize).InclusiveBetween(0, 50);

        }
    }
}