using etgarPlus.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace etgarPlus.Logic
{
    public class ProducerBL
    {
        public ProducerDAL producerDAL;
        public ProducerBL()
        {
            producerDAL = new ProducerDAL();
        }
		public void AddNeproducer(int NewId, string NewProducer)
        {
            producerDAL.AddNeproducer(NewId, NewProducer);
        }
        public void deleteProducer(int NewId)
        {
            producerDAL.deleteBikeByProducer(NewId);
        }
        public List<Classes.Producer> getAllProducer()
        {
            return (producerDAL.getAllProducer());
        }
        public string GetProducer(int ID)
        {
            return (producerDAL.GetProducer(ID));
        }
		public int getMaxIdProducer()
        {
            return producerDAL.maxIdProducer() + 1;

        }
	}
}