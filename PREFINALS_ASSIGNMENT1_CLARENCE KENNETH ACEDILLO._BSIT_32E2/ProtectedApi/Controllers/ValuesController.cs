using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<object> Get()
        {
            var user = HttpContext.User.Identity.Name;
            var userSection = "32E2";
            var userCourse = "Bachelor of Science in Information Technology";

            var funFacts = new List<string>
            {
                "The Creator loves to sleep.",
                "My name is Aaron Zach C. Anzorandia",
                "I really love to listen to music, especially loud music.",
                "I hit the gym for clearing my mind and conquering challenges, both physical and emotional.",
                "I may be shy, but my spirit shines through when i'm along with my close friends.",
                "My Favorite hobby is playing drums and gigging in various kinds of events with my band.",
                "I used to play basketball when i'm bored.",
                "I'm the master of my faith.",
                "I love graphic designing",
                "NPC Energy."
            };

            // Random generator
            var random = new Random();
            var selectedFacts = new List<string>();
            for (int i = 0; i < 3; i++)
            {
                var index = random.Next(funFacts.Count);
                selectedFacts.Add(funFacts[index]);
                funFacts.RemoveAt(index);
            }

            return new
            {
                UserName = user,
                Section = userSection,
                Course = userCourse,
                FunFacts = selectedFacts
            };
        }
    }
}