using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sionnach
{
    public enum objectiveType { clay, mana, food, wood, stone, pots, spears, building}

    public class TrackingEvent
    {
        public int desiredCount;
        public int id;
        public List<int> triggerEvents;
        public bool active = false;
        public bool finished = false;

        public objectiveType typeOfEvent;

        public bool tutorialPopup = false;

        public string unfinishedString;
        public string finishedString;

        public TrackingEvent(int desId, List<int> desTriggerEvents, int desCount, objectiveType desObjectiveType, string unfin, string fin, bool tut = false)
        {
            id = desId;
            triggerEvents = desTriggerEvents;
            desiredCount = desCount;
            typeOfEvent = desObjectiveType;
            unfinishedString = unfin;
            finishedString = fin;
            tutorialPopup = tut;

            if (id == 0)
            {
                active = true;
            }
        }
    }
    class EventManager
    {
        List<TrackingEvent> eventsToTrack;
        UI ui;

        public EventManager(UI stateUI)
        {
            ui = stateUI;
            eventsToTrack = new List<TrackingEvent>();
        }

        public void addEvent(TrackingEvent eventToTrack)
        {
            eventsToTrack.Add(eventToTrack);
        }

        public void addEvent(List<TrackingEvent> newEventsToTrack)
        {
            foreach (TrackingEvent eventToTrack in newEventsToTrack)
            {
                eventsToTrack.Add(eventToTrack);
            }

        }

        public void completeEvent(TrackingEvent eventToTrack)
        {
            ui.addPopup(eventToTrack.finishedString);
            eventToTrack.finished = true;
            eventToTrack.active = false;
            foreach (int i in eventToTrack.triggerEvents)
            {
                foreach (TrackingEvent eve in eventsToTrack)
                {
                    if (i == eve.id)
                    {
                        eve.active = true;
                        Console.WriteLine(eve.unfinishedString);
                    }
                }
            }
            eventsToTrack.Remove(eventToTrack);
        }

        public void checkEvents()
        {
            
        }

        public List<TrackingEvent> getObjectives()
        {
            List<TrackingEvent> returnList = new List<TrackingEvent>();

            foreach (TrackingEvent e in eventsToTrack)
            {
                if (e.tutorialPopup == false && e.active == true)
                {
                    returnList.Add(e);
                }
            }

            return returnList;
        }
    }
}
