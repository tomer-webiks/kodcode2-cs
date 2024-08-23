using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace IronDome.Models
{

    public class Attack
    {
        [Key]
        public int ID { get; set; }
        public DateTime? StartTime { get; set; }
        public int Count { get; set; }
        [DisplayName("Type")]
        public int? TypeId { get; set; }
        public AttackType? Type { get; set; }
        [DisplayName("Origin")]
        public int? OriginId { get; set; }
        public AttackOrigin? Origin { get; set; }
        public Boolean IsActive { get; set; }

        [NotMapped]
        [DisplayName("Time To Impact")]
        public int TimeToImpact
        {
            get
            {
                if (!IsActive || (Type == null || Origin == null || StartTime == null))
                {
                    return -1;
                }

                DateTime currentTime = DateTime.Now;
                TimeSpan timeDifference = currentTime - (DateTime)StartTime;

                // Convert speed from km/h to km/s
                double speedKms = (double)Type.SpeedKMH / 3600;

                // Distance in kilometers
                double distanceKm = (double)Origin.DistanceKM;

                // Time to impact in seconds
                double timeToImpactSeconds = distanceKm / speedKms - timeDifference.TotalSeconds;

                return timeToImpactSeconds < 0 ? 0 : (int)timeToImpactSeconds;
            }
        }

    }



    public interface IAttack
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

    public class AttackType : IAttack
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SpeedKMH { get; set; }
    }

    public class AttackOrigin : IAttack
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int DistanceKM { get; set; }

    }

}
