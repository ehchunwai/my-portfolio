using myportfolio.Database;
using myportfolio.Models;
using System;
using System.Collections.Generic;

namespace myportfolio.Modules
{
    public class TestimonialService
    {
        private IStoreTestimonial _storeTestimonial = null;

        public TestimonialService(IStoreTestimonial storeTestimonial)
        {
            _storeTestimonial = storeTestimonial;
        }

        public List<TestimonialModel> GetTestimonialList(Guid uid)
        {
            var result = _storeTestimonial.GetTestimonialList(uid);
            return result;
        }
    }
}
