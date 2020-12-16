using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DatetimeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DateTimeJSONController : ControllerBase
    {
        // GET api/<DateTimeJSONController>/5
        [HttpGet("{id}")]
        public IActionResult Weekday(int? id = null)
        {
            List<WeekDay> weekDays = new List<WeekDay>();

            foreach (int arrayDayIndex in Enumerable.Range(0, 7))
            {
                weekDays.Add(new WeekDay
                {
                    DayOfWeek = $"{arrayDayIndex}. {DateTime.Now.DayOfWeek}",
                    OptionParam = (id == null),
                    Date = DateTime.Now.AddDays(arrayDayIndex),
                    Time = DateTime.Now.TimeOfDay,
                    NextDayTime = DateTime.Now.AddDays(1).TimeOfDay,
                    SecondAfterDayTime = DateTime.Now.AddDays(2).TimeOfDay
                });
            }

            return new JsonResult(weekDays);
        }

        // POST api/<DateTimeJSONController>
        [HttpPost]
        public IActionResult Weekday([FromBody] DateTime[] dateTimes)
        {
            List<WeekDay> weekDays = new List<WeekDay>();

            short counter = 0;

            foreach (DateTime arrayDate in dateTimes)
            {
                weekDays.Add(new WeekDay
                {
                    DayOfWeek = $"{counter}. {arrayDate.DayOfWeek}",
                    OptionParam = false,
                    Date = arrayDate.AddDays(counter++),
                    Time = arrayDate.TimeOfDay,
                    NextDayTime = arrayDate.AddDays(1).TimeOfDay,
                    SecondAfterDayTime = arrayDate.AddDays(2).TimeOfDay
                });
            }

            return new JsonResult(weekDays);
        }
    }
}
