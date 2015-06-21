using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using SoundyAPI.Models;

namespace SoundyAPI.Controllers
{
    public class SoundsController : ApiController
    {
        private SoundyDbContext db = new SoundyDbContext();

        // GET: api/Sounds
        public IQueryable<Sound> GetSounds()
        {
            return db.Sounds;
        }

        // GET: api/Sounds/5
        [ResponseType(typeof(Sound))]
        public IHttpActionResult GetSound(Guid id)
        {
            Sound sound = db.Sounds.Find(id);
            if (sound == null)
            {
                return NotFound();
            }

            return Ok(sound);
        }

        // PUT: api/Sounds/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSound(Guid id, Sound sound)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sound.Id)
            {
                return BadRequest();
            }

            db.Entry(sound).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SoundExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Sounds
        [ResponseType(typeof(Sound))]
        public IHttpActionResult PostSound(Sound sound)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Sounds.Add(sound);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (SoundExists(sound.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = sound.Id }, sound);
        }

        // DELETE: api/Sounds/5
        [ResponseType(typeof(Sound))]
        public IHttpActionResult DeleteSound(Guid id)
        {
            Sound sound = db.Sounds.Find(id);
            if (sound == null)
            {
                return NotFound();
            }

            db.Sounds.Remove(sound);
            db.SaveChanges();

            return Ok(sound);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SoundExists(Guid id)
        {
            return db.Sounds.Count(e => e.Id == id) > 0;
        }
    }
}