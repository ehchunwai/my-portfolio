using myportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myportfolio.Database
{
    public interface IStoreTestimonial
    {
        List<TestimonialModel> GetTestimonialList(Guid uid);
    }

    public class StoreTestimonial : IStoreTestimonial
    {
        List<TestimonialModel> _testimonialList = new List<TestimonialModel>();

        public StoreTestimonial()
        {
            _testimonialList = new List<TestimonialModel>()
            {
            new TestimonialModel(){
            Name = "Alvin Siah, Ex Senior Manager of Recogine Technology Sdn Bhd",
            Description ="His commitment and responsibility towards work is extraordinary. Combining with his good skillset in programming, he had been a great lead team lead in the team.",
            ImageSource = "/media/testimonial/alvin.jpg",
            LinkedInLink = "https://www.linkedin.com/in/alvin-siah-5957133b/",
            TagLine = "A great team lead in the team.",
            ProfileId = System.Guid.Empty},
            new TestimonialModel()
            {
            Name = "Harith Rosli, Ex Lead Engineer (Applications) of Recogine Technology Sdn Bhd",
              ImageSource = "/media/testimonial/harith.jpg",
            LinkedInLink = "https://www.linkedin.com/in/harith-rosli-9003211ab/",
             TagLine = "A great teammate to work with.",
            ProfileId = System.Guid.Empty},
               new TestimonialModel()
            {
            Name = "Ashvin Naidu, Ex Assistant Manager (Project and Systems) of Recogine Technology Sdn Bhd",
              ImageSource = "/media/testimonial/ashvin.jpg",
            LinkedInLink = "https://www.linkedin.com/in/ashvin-naidu-retna-kumar-5889aab4/",
             TagLine = "Knowledgeable in software system architecture.", Description = "",
            ProfileId = System.Guid.Empty}};
        }

        public List<TestimonialModel> GetTestimonialList(Guid uid)
        {
            return _testimonialList.Where(t => t.ProfileId == uid).ToList();
        }
    }
}
