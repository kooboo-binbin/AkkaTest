﻿using Akka.Actor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AkkaOrder.Actors
{
    public class FailureActors
    {
        public class SupervisingActor : UntypedActor
        {
            private IActorRef child = Context.ActorOf(Props.Create<SupervisedActor>(), "supervised-actor");

            protected override void OnReceive(object message)
            {
                switch (message)
                {
                    case "failChild":
                        child.Tell("fail");
                        break;
                }
            }
        }

        public class SupervisedActor : UntypedActor
        {
            protected override void PreStart() => Console.WriteLine("supervised actor started");
            protected override void PostStop() => Console.WriteLine("supervised actor stopped");

            protected override void OnReceive(object message)
            {
                switch (message)
                {
                    case "fail":
                        Console.WriteLine("supervised actor fails now");
                        throw new Exception("I failed!");
                }
            }
        }
    }
}
