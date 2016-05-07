using CarrierRating.Domain.Entities.MongoEntities;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarrierRating.Domain.Entities.Base
{
    public class Person: MongoEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date), 
         DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Birthdate { get; set; }
        public virtual string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
