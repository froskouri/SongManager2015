using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using SongManager.DataAccess;

namespace SongManager.API.Controllers
{
    [Route("api/[controller]")]
    public class SongsController : Controller
    {
        private IContext _context;

        public SongsController(IContext context)
        {
            _context = context;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Song> Get()
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                return unitOfWork.GetRepository<Song>().Get().AsEnumerable();
            }
        }

        // GET api/values/5
        [HttpGet("{name}")]
        public Song Get(string name)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                return unitOfWork.GetRepository<Song>().Get().Where(q => q.Name.Equals(name)).First();
            }
        }

        // POST api/values
        [HttpPost]
        public void Post(string name, string artist)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                var song = new Song() { Name = name, Artist = artist, Id = Guid.NewGuid() };
                unitOfWork.GetRepository<Song>().Insert(song);
                unitOfWork.CommitChanges();
            }
        }

        // PUT api/values/5
        [HttpPut("{name}")]
        public void Put(string name, string artist)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                var song = unitOfWork.GetRepository<Song>().Get().Where(q => q.Name.Equals(name)).First();
                song.Artist = artist;
                unitOfWork.GetRepository<Song>().Edit(song);
                unitOfWork.CommitChanges();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{name}")]
        public void Delete(string name)
        {
            using (var unitOfWork = _context.CreateUnitOfWork())
            {
                var song = unitOfWork.GetRepository<Song>().Get().Where(q => q.Name.Equals(name)).First();
                unitOfWork.GetRepository<Song>().Delete(song);
                unitOfWork.CommitChanges();
            }
        }
    }
}
