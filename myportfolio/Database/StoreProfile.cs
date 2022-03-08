using myportfolio.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace myportfolio.Database
{
    public interface IStoreProfile
    {
        public Profile GetProfile(Guid uid);
    }

    public class StoreProfile : IStoreProfile
    {
        List<Profile> _profileList = new List<Profile>();

        public StoreProfile()
        {
            _profileList = new List<Profile>();
            _profileList.Add(new Profile()
            {
                ProfileId = Guid.Empty,
                Quote = "The most important aspect for me is to improve myself and take on more responsibility in work. I’m ready for a new challenge in my career. I’d also like to continue to grow, learn, and also take on some new tasks that I haven’t had the opportunity to tackle in my current role.",
                DOB = new DateTime(1991, 12, 17),
                Address = "No 6, jalan seri banang 12, Taman Sri Andalas Klang 41200, Selangor.",
                ContactNo = "011-56288991",
                Email = "eh.chunwai@gmail.com",
                LanguageList = new List<string>() { "English", "Mandarin", "Bahasa Malaysia" },
                NoOfProjectCompleted = 10,
                SkillsOverview = "I started off my career maintaining products using Microsoft's windows form applications and using CRUD functions on SQL Server. Slowly I transition into backend business logic, interface with 3rd party systems and designing architecture for systems. As my career progresses, I moved on to web development due to its \"access from anywhere!\" platform.",
                OtherList = new List<string>() { "IDE used are Microsoft's Visual Studio and Visual Studio Code.", "GitHub for source control.", "Communication that I have touched on are Microsoft's message queue, WCF, TCP/IP, UDP, REST API, Modbus TCP, Serial communication." },
            });
        }

        Profile IStoreProfile.GetProfile(Guid uid)
        {
            var result = _profileList.Where(t => t.ProfileId == Guid.Empty).FirstOrDefault();
            return result;
        }
    }
}
