using System.ComponentModel.DataAnnotations;

namespace Odarms.Data.Service.Enums
{
    public enum SubscriptionDuration
    {
        [Display(Name = "Six Months")]
        SixMonths,
        [Display(Name = "One Year")]
        OneYear,
        [Display(Name = "Two Years")]
        TwoYears,
        [Display(Name = "Three Years")]
        ThreeYears
    }
}
