using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Dtos;
using Core.Entities;
using Core.Interfaces;
using Infrastucture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PlaceController : ControllerBase
    {
        private readonly IPlaceRepository _repo;
        public PlaceController(IPlaceRepository repo)
        {
            _repo = repo;
        }


        [HttpGet]
        public async Task<ActionResult<List<Place>>> GetPlaces()
        {
            var places = await _repo.GetPlacesAsync();

            return Ok(places);

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
            // string connectionString = "Server = localhost; Database= globatourspoo; User Id = root; Password = '';";
            // var places = new List<Place>();

            // MySqlConnection connection = new MySqlConnection(connectionString);
            // MySqlDataReader reader = null;

            // try
            // {
            //     string query = "SELECT Name FROM place;";

            //     MySqlCommand command = new MySqlCommand(query);

            //     command.Connection = connection;

            //     connection.Open();

            //     reader = command.ExecuteReader();

            //     while (reader.Read()) //Avanza MySqlDataReader al siguiente registro
            //     {
            //         string name = reader.GetString(0);
            //         Place place = new Place(name);
            //         places.Add(place);
            //     }
            //     reader.Close();
            //     return Ok(places);
            // }
            // catch (System.Exception)
            // {
            //     throw new Exception("error reading the data");
            // }
            // finally
            // {
            //     connection.Close();
            // }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Place>> GetPlace(int id)
        {
            return await _repo.GetPlaceAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult<bool>> AddPlace(DtoPlace model)
        {
            if (await _repo.AddPlace(model))
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
            // string connectionString = "Server = localhost; Database= globatourspoo; User Id = root; Password = '';";

            // MySqlConnection connection = new MySqlConnection(connectionString);

            // try
            // {
            //     string query = "INSERT INTO `place`(`Name`, `State`, `UserCreatorId`, `UserModifierId`, `CreatedAt`, `UpdatedAt`) " +
            //     "VALUES (@name, @state, @userCreatorId, @userModifierId, @createdAt, @updateAt);";

            //     MySqlCommand command = new MySqlCommand(query);

            //     command.Connection = connection;
            //     command.Parameters.AddWithValue("@name", model.Name);
            //     command.Parameters.AddWithValue("@state", true);
            //     command.Parameters.AddWithValue("@userCreatorId", "Yaisel");
            //     command.Parameters.AddWithValue("@userModifierId", "Yaisel");
            //     command.Parameters.AddWithValue("@createdAt", DateTime.Now);
            //     command.Parameters.AddWithValue("@updateAt", DateTime.Now);

            //     connection.Open();
            //     command.ExecuteNonQuery();

            //     return Ok(true);
            // }
            // catch (System.Exception)
            // {
            //     throw new Exception("error adding the data");
            // }
            // finally
            // {
            //     connection.Close();
            // }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
        }

        [HttpPut]
        public async Task<ActionResult<bool>> UpdatePlace(int id, DtoPlace model)
        {

            if (await _repo.EditdPlace(id, model))
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
            // string connectionString = "Server = localhost; Database= globatourspoo; User Id = root; Password = '';";

            // MySqlConnection connection = new MySqlConnection(connectionString);

            // try
            // {
            //     string query = "UPDATE `place` SET `Name`=@name WHERE `Id`=@id";

            //     MySqlCommand command = new MySqlCommand(query);

            //     command.Connection = connection;
            //     command.Parameters.AddWithValue("@name", model.Name);
            //     command.Parameters.AddWithValue("@id", id);

            //     connection.Open();
            //     command.ExecuteNonQuery();

            //     return Ok(true);
            // }
            // catch (System.Exception)
            // {
            //     throw new Exception("error updating the data");
            // }
            // finally
            // {
            //     connection.Close();
            // }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
        }

        [HttpDelete]
        public async Task<ActionResult<bool>> DeletePlace(int id)
        {
            if (await _repo.DeletePlace(id))
            {
                return Ok(true);
            }
            else
            {
                return BadRequest(false);
            }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
            // string connectionString = "Server = localhost; Database= globatourspoo; User Id = root; Password = '';";

            // MySqlConnection connection = new MySqlConnection(connectionString);

            // try
            // {
            //     string query = "DELETE FROM `place` WHERE `Id`=@id";

            //     MySqlCommand command = new MySqlCommand(query);

            //     command.Connection = connection;
            //     command.Parameters.AddWithValue("@id", id);

            //     connection.Open();
            //     command.ExecuteNonQuery();

            //     return Ok(true);
            // }
            // catch (System.Exception)
            // {
            //     throw new Exception("error deleting the data");
            // }
            // finally
            // {
            //     connection.Close();
            // }

            /* **************************** ****************************** SIN ENTITY FRAMEWORK *****************************************/
        }
    }
}