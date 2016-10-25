using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Obalon.Models;
using Obalon.Services;

namespace Obalon.Controllers
{
    public class EventsController : Controller
    {
        private readonly IEventService eventsService;

        public EventsController(IEventService eventsService)
        {
            this.eventsService = eventsService;
        }

        public async Task<ActionResult> Index(int id)
        {
            var events = eventsService.GetEvents(id);
            ViewBag.PatientId = id;
            return View(events);
        }

        public ActionResult Create(int id)
        {
            ViewBag.EventTypes = eventsService.AvailableEventTypes(id); //new SelectList(db.EventTypes, "EventTypeId", "EventTypeName");
            ViewBag.PatientId = id;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(FormCollection collection)//[Bind(Include = "EventId,EventTypeId,PatientId,Days,Weight,SeriousInjury")] Event @event)
        {
            if (ModelState.IsValid)
            {
                string inj = collection["injury"];
                int eventTypeId, weight, patientId;
                DateTime eventDate, firstBalloonDate;

                if (int.TryParse(collection["ddlEvents"], out eventTypeId)
                    && DateTime.TryParseExact(collection["eventDate"], "mm/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out eventDate)
                    && DateTime.TryParseExact(collection["firstBalloonDate"], "mm/dd/yyyy", null, System.Globalization.DateTimeStyles.None, out firstBalloonDate)
                    && int.TryParse(collection["weight"], out weight)
                    && int.TryParse(collection["patient"], out patientId))
                {
                    Event evt = new Event()
                    {
                        PatientId = patientId,
                        EventTypeId = eventTypeId,
                        Days = (int)(eventDate - firstBalloonDate).TotalDays,
                        Weight = weight,
                        SeriousInjury = (inj == "yes")
                    };

                    eventsService.Save(evt);
                    return RedirectToAction("Index", "Event", new { id = patientId });
                }
            }

            return RedirectToAction("Index");
        }

        // GET: Events/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName", @event.EventTypeId);
        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientId", @event.PatientId);
        //    return View(@event);
        //}

        //// POST: Events/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "EventId,EventTypeId,PatientId,Days,Weight,SeriousInjury")] Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@event).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.EventTypeId = new SelectList(db.EventTypes, "EventTypeId", "EventTypeName", @event.EventTypeId);
        //    ViewBag.PatientId = new SelectList(db.Patients, "PatientId", "PatientId", @event.PatientId);
        //    return View(@event);
        //}

        //// GET: Events/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Event @event = await db.Events.FindAsync(id);
        //    db.Events.Remove(@event);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}


    }
}
