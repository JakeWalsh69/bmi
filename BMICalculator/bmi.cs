// model classes for BMI calculator
// GC

using System;
using System.ComponentModel.DataAnnotations;

namespace BMICalculator
{
    public enum BMICategory { Underweight, Normal, Overweight, Obese };
    public enum CalorieRange { Low, Average, High, Excessive };

    public class BMI
    {
        const double UnderWeightUpperLimit = 18.4;              // inclusive upper limit
        const double NormalWeightUpperLimit = 24.9;
        const double OverWeightUpperLimit = 29.9;               // Obese from 30 +

        // conversion factors from imperial to metric
        const double PoundsToKgs = 0.453592;
        const double InchestoMetres = 0.0254;

        [Display(Name = "Gender")]
        public String PersonGender { get; set; }

        [Display(Name = "Calories Per Day")]
        [Range(0, 10000, ErrorMessage = "Calorie intake must be between 0 and 10000")]
        public int CaloriesIntake { get; set; }

        [Display(Name = "Weight - Stones")]
        [Range(5, 50, ErrorMessage = "Stones must be between 5 and 50")]                              // max 50 stone
        public int WeightStones { get; set; }

        [Display(Name = "Pounds")]
        [Range(0, 13, ErrorMessage = "Pounds must be between 0 and 13")]                              // 14 lbs in a stone
        public int WeightPounds { get; set; }

        [Display(Name = "Height - Feet")]
        [Range(4, 7, ErrorMessage = "Feet must be between 4 and 7")]                               // max 7 feet
        public int HeightFeet { get; set; }

        [Display(Name = "Inches")]
        [Range(0, 11, ErrorMessage = "Inches must be between 0 and 11")]                              // 12 inches in a foot
        public int HeightInches { get; set; }

        // calculate BMI, display to 2 decimal places
        [Display(Name = "Your BMI is")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public double BMIValue
        {
            get
            {
                // bmi = weight in Kgs / height in metres squared

                double totalWeightInPounds = (WeightStones * 14) + WeightPounds;
                double totalHeightInInches = (HeightFeet * 12) + HeightInches;

                // do conversions to metric
                double totalWeightInKgs = totalWeightInPounds * PoundsToKgs;
                double totalHeightInMetres = totalHeightInInches * InchestoMetres;

                double bmi = totalWeightInKgs / (Math.Pow(totalHeightInMetres, 2));

                return bmi;
            }
        }

        // calculate BMI category 
        [Display(Name = "Your BMI Category is")]
        public BMICategory BMICategory
        {
            get
            {
                double bmi = this.BMIValue;

                // calculate BMI category based on upper limits
                if (bmi <= UnderWeightUpperLimit)
                {
                    return BMICategory.Underweight;
                }
                else if (bmi <= NormalWeightUpperLimit)
                {
                    return BMICategory.Normal;
                }
                else if (bmi <= OverWeightUpperLimit)
                {
                    return BMICategory.Overweight;
                }
                else
                {
                    return BMICategory.Obese;
                }
            }
        }

        public CalorieRange CalorieRange
        {
            get
            {
                int calories = this.CaloriesIntake;

                if (this.PersonGender == "male" && calories >= 0 && calories < 2000)
                {
                    return CalorieRange.Low;
                }
                else if (this.PersonGender == "female" && calories >= 0 && calories < 1700)
                {
                    return CalorieRange.Low;
                }
                else if (this.PersonGender == "male" && calories >= 2000 && calories < 3000)
                {
                    return CalorieRange.Average;
                }
                else if (this.PersonGender == "female" && calories >= 1700 && calories < 2600)
                {
                    return CalorieRange.Average;
                }
                else if (this.PersonGender == "male" && calories >= 3000 && calories < 4000)
                {
                    return CalorieRange.High;
                }
                else if (this.PersonGender == "female" && calories >= 2600 && calories < 3500)
                {
                    return CalorieRange.High;
                }
                else if (this.PersonGender == "male" && calories >= 4000 && calories < 10000)
                {
                    return CalorieRange.Excessive;
                }
                else 
                {
                    return CalorieRange.Excessive;
                }
            }
        }
    }
}

