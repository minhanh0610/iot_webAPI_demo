using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Web_api.Data;
using Web_api.Models;

namespace Web_api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SensorDatasController : ControllerBase
    {
        private readonly Web_apiContext _context;

        public SensorDatasController(Web_apiContext context)
        {
            _context = context;
        }

        // GET: api/SensorDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SensorData>>> GetSensorData()
        {
            SensorData[] s = await _context.SensorData.ToArrayAsync();
            return s;
        }
        
        // GET: api/SensorDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SensorData>> GetSensorDataDetails(int id)
        {

            SensorData sensorData = await _context.SensorData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sensorData == null)
            {
                return NotFound();
            }

            return sensorData;
        }

        // POST: api/SensorDatas/5
        [HttpPost]
        public async Task<ActionResult<SensorData>> PostSensorData(SensorData sensorData)
        {
            _context.SensorData.Add(sensorData);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetSensorData", new { id = sensorData.Id }, sensorData);
        }

        // PUT: api/SensorDatas/5
        [HttpPut("{id}")]
        public async Task<ActionResult<SensorData>> PutSensorData(int id, SensorData sensorData)
        {
            if(id != sensorData.Id)
            {
                return BadRequest();
            }
            _context.Entry(sensorData).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SensorDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        //DELETE api/SensorDatas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SensorData>> DeleteSensorData(int id)
        {
            SensorData sensorData = await _context.SensorData.FindAsync(id);
            if(sensorData == null)
            {
                return NotFound();
            }
            _context.SensorData.Remove(sensorData);
            await _context.SaveChangesAsync();
            return sensorData;
        }

        private bool SensorDataExists(int id)
        {
            return _context.SensorData.Any(e => e.Id == id);
        }
        
    }
}
