using System;

namespace ConsoleDummy
{
    internal static class DummyDtoHelpers
    {


        public readonly static Func<DummyDto, Dummy> dummyMap = e =>
        {
            return new Dummy
            {
                name = e.employee_name,
                document_number = null,
                salary = e.employee_salary,
                age = e.employee_age,
                profile = e.profile_image,
                address = null,
                phone_number = null
            };
        };
    }
}