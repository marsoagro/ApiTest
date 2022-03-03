using MarsoApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MarsoApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/grupos")]
   
    public class GRUPOController : ApiController
    {
        apiEntities db = new apiEntities();

        public GRUPOController() { }
        /// <summary>
        ///Metodo que inserta los grupos a la base de datos
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Add(Models.ViewModel.GrupoViewModel model)
        {
            Guid ultimo = new Guid();
            using (apiEntities db = new apiEntities())
            {
                var OGROUP = new Models.GRUPO() { Id=Guid.NewGuid(), Descripcion=model.DESC };
                db.GRUPO.Add(OGROUP);
                db.SaveChanges();
                ultimo = OGROUP.Id;
            }


            return Ok("Grupo Guardado" + ultimo);
        }

        /// <summary>
        ///Obtenemos un listado de los grupos existentes
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Get()
        {
            List<Models.ViewModel.GrupoViewModel> list = new List<Models.ViewModel.GrupoViewModel>();
            using (apiEntities db = new apiEntities())
            {
                list = (from d in db.GRUPO
                        select new Models.ViewModel.GrupoViewModel
                        {
                            ID = d.Id,
                            DESC = d.Descripcion

                        }).ToList();
            }

            return Ok(list);
        }
        [HttpPut]
        public IHttpActionResult Put(Models.ViewModel.GrupoViewModel model)
        {

            if (!ModelState.IsValid)
                return BadRequest("Modelo no válido");

            using (apiEntities db = new apiEntities())
            {
                var existingGroup = (from p in db.GRUPO.Where(s => s.Id == model.ID)
                                     select p).FirstOrDefault();

                if (existingGroup != null)
                {
                    existingGroup.Descripcion = model.DESC;


                    db.SaveChanges();
                }
                else
                {
                    return NotFound();
                }
            }

            return Ok("Grupo Actualizado");
        }
            
        [HttpDelete]
        public IHttpActionResult Delete(Guid id)
        {
            if (string.IsNullOrEmpty(id.ToString()))
                return BadRequest("Geupo no valido");
                  

            using (apiEntities db = new apiEntities())
            {
                var existingGroup = (from p in db.GRUPO.Where(s => s.Id ==  id)
                                     select p).FirstOrDefault();
                db.Entry(existingGroup).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();

            }

            return Ok("Grupo Eliminado");
        }

    }
}
