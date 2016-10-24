using Obalon.Models;
using Obalon.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Obalon.Services
{
    public interface IEventService
    {
        ResponseItemList<Event> GetEvents(int patientId);

        ResponseItemList<Event> SearchEvents(); // tb si niste criterii : .. evenimente ?

        ResponseItem<Event> GetEvent(int pacientId);

        List<SelectListItem> AvailableEvents(int patientId);

        int Add(Event p);

        string Test();
    }
    public class EventService : IEventService
    {
        public static List<SelectListItem> AvailableEvents(int patientId)
         {

            List<SelectListItem> eventsSelect = new List<SelectListItem>();
            List<EventType> eventTypes = new List<EventType>();

            using (var db = new ObalonEntities())
            {
                Patient patient = db.Patients.Find(patientId);
                eventTypes.AddRange(from ev in db.EventTypes where ev.IsRoutineAction == true select ev);
                if (patient != null && patient.Events.Count > 0 && patient.LastUserEventType > 0)
                {
                    eventTypes.Add((from evt in db.EventTypes
                                    where evt.EventTypeId != patient.LastUserEventType
                                    && evt.IsRoutineAction == false
                                    orderby evt.EventTypeId
                                    select evt)
                                        .FirstOrDefault());
                }
                else
                {
                    var availableEventType = (from evt in db.EventTypes
                                              where evt.IsRoutineAction == false
                                              orderby evt.EventTypeId ascending
                                              select evt).FirstOrDefault();
                    if (availableEventType != null)
                        eventTypes.Add(availableEventType);
                }
            }


            if (eventTypes.Count > 0)
            {
                foreach (var evt in eventTypes.OrderBy(ev => ev.EventTypeId).ToList())
                    eventsSelect.Add(new SelectListItem() { Text = evt.EventTypeName, Value = evt.EventTypeId.ToString() });

            }

            return eventsSelect;
        }


        public int Add(Event e)
        {
            throw new NotImplementedException();
        }

        public ResponseItem<Event> GetEvent(int pacientId)
        {
            throw new NotImplementedException();
        }

        public ResponseItemList<Event> GetEvents(int patientId)
        {
            throw new NotImplementedException();
        }

        public ResponseItemList<Event> SearchEvents()
        {
            throw new NotImplementedException();
        }

        public string Test()
        {
            throw new NotImplementedException();
        }

        List<SelectListItem> IEventService.AvailableEvents(int patientId)
        {
            throw new NotImplementedException();
        }
    }
}