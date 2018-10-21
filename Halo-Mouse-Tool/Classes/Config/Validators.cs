﻿using Registrar;
using System;
using System.Windows.Forms;

namespace Halo_Mouse_Tool.Classes.ConfigValidators
{
    public class Validators
    {
        class SensitivityValidator : IValidator
        {
            public string Description()
            {
                return "Value must be between 0.1 and 20.0";
            }

            public bool Validate(object value)
            {
                float convertedValue = ValidatorConverters.ValidatorFloatConverter(value);
                return (convertedValue >= 0.1f && convertedValue <= 20.0f);
            }
        }

        class BoolValidator : IValidator
        {
            public string Description()
            {
                return "Value must be a boolean (1 or 0 in registry)";
            }

            public bool Validate(object value)
            {
                bool convertedValue = ValidatorConverters.ValidatorBooleanConverter(value);
                return convertedValue;
            }
        }

        class IncrementAmountValidator : IValidator
        {
            public string Description()
            {
                return "Value must be between 0.1 and 5.0";
            }

            public bool Validate(object value)
            {
                float convertedValue = ValidatorConverters.ValidatorFloatConverter(value);
                return (convertedValue >= 0.1f && convertedValue <= 5.0f);
            }
        }

        class HotkeyValidator : IValidator
        {
            public string Description()
            {
                return "Must be a valid key";
            }

            public bool Validate(object value)
            {
                string convertedValue = ValidatorConverters.ValidatorStringConverter(value);

                try
                {
                    Keys convertedKey = (Keys)Enum.Parse(typeof(Keys), convertedValue, true);
                }
                catch (ArgumentException)
                {
                    return false;
                }

                return true;
            }
        }

        public IValidator SensitivityValidatorInstance = new SensitivityValidator();
        public IValidator BoolValidatorInstance = new BoolValidator();
        public IValidator IncrementAmountValidatorInstance = new IncrementAmountValidator();
        public IValidator HotkeyValidatorInstance = new HotkeyValidator();
    }
}
