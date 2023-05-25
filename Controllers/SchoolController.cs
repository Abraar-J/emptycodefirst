using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace emptycodefirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly SchoolContext con;
        public SchoolController(SchoolContext _con)
        {
            this.con = _con;
        }
        [HttpGet]
        public async Task<ActionResult< IEnumerable<Student>>> GetStudent()
        {
            return await con.Students.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            Student st=await con.Students.FirstOrDefaultAsync(x => x.Id == id);
            return st;
        }
        [HttpPost]
        public async Task<ActionResult> PostStudent(Student su)
        {
            await con.Students.AddAsync(su);
            con.SaveChanges();
            return Ok(su);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id,Student stu)
        {
            Student st=await con.Students.FirstOrDefaultAsync(x=>x.Id== id);
            st.Id = stu.Id;
            st.Name=stu.Name;
            st.age = stu.age;
            con.Students.Update(st);
            con.SaveChanges();
            return Ok(st);
        }

        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeleteStudent(int id)
        {
            Student st = await con.Students.FirstOrDefaultAsync(x => x.Id == id);
            con.Students.Remove(st);
            con.SaveChanges();
            return Ok(st);
        }
    }
}
