using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace MM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {

            //BookContext context = new BookContext();
            //BookRepository bookRepository = new BookRepository(context);
            //bookRepository.AddBook("Sridhar", "Sridhar");
            //bookRepository.GetById(2);
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("CharStream/{text}/{letter}/{radius}")]
        public ActionResult<CharCount> Get(string text, char letter, int radius)
        {
            var result = CharRadius(text, letter, radius);
            return Ok(result);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
            BookContext context = new BookContext();
            BookRepository bookRepository = new BookRepository(context);
            bookRepository.AddBook("Sridhar", "Sridhar");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public CharCount CharRadius(string text, char letter, int radius)
        {
            CharCount ccount = new CharCount();
            if (radius == 0)
            {
                ccount.Count = 1;
                ccount.Found = letter.ToString();
                ccount.Percent = (0 * 10);
                return ccount; ;
            }
            string temp = "";
            string temp1 = "";
            string output1 = "", o = "";
            char t = letter, k = letter; ;
            for (int i = 0; i < radius; i++)
            {
                temp += (++t).ToString();
                temp1 += (--k).ToString();
            }
            char[] c = temp1.ToCharArray();
            Array.Reverse(c);
            temp1 = new string(c);
            o = temp1 + letter.ToString() + temp;
            foreach (char item in o)
            {
                if (text.Contains(item.ToString()))
                {
                    output1 += item.ToString();
                }
            }
            ccount.Found = output1; ccount.Count = output1.Length; ccount.Percent = (radius * 10);
            return ccount;
        }
    }
    public class CharCount
    {
        public string Found { get; set; }
        public int Count { get; set; }
        public int Percent { get; set; }
    }
    public interface IDisplay
    {
        int Size { get; set; }
    }
    public abstract class AbsDemo
    {
        public abstract int Size { get; set; }
    }
    public class AbsDemoDerived: AbsDemo
    {
        public override int Size { get ; set; }
    }
}
