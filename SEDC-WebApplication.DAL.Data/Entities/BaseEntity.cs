using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC_WebApplication.DAL.Data.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity(int? id)
        {
            this.EntityState = id.HasValue ? EntityStateEnum.Loaded : EntityStateEnum.New;
            this.Id = id;
        }

        public int? Id { get; set; }

        public EntityStateEnum EntityState { get; set; }
    }
}
