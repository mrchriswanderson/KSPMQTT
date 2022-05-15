using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MqttLib;

namespace KSPMQTTLbary;

class MQTTRangeSafetySystem : MQTTPartModule
{

    public override void OnStart(PartModule.StartState state)
    {
        base.OnStart(state);
        client.PublishArrived += new PublishArrivedDelegate(client_PublishArrived);
        client.Subscribe("ksp/test1/cmd/rss", QoS.BestEfforts);   // Subscribe to rss command topic
        print("Range Safety System subscribed to command topic");
    }

    bool client_PublishArrived(object sender, PublishArrivedArgs e)
    {
        part.parent.explode();
        part.explode();
        return true;
    }

}