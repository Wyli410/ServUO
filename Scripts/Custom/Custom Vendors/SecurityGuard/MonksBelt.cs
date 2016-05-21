using System;
using Server;

namespace Server.Items
{
    public class MonksBelt : BaseWaist
    {
        [Constructable]
        public MonksBelt()
            : this(0)
        {
        }

        [Constructable]
        public MonksBelt(int hue)
            : base(0x2B68, 2652)
        {
            this.Weight = 1.0;
            this.Name = "A Monk's Belt";
        }

        public MonksBelt(Serial serial)
            : base(serial)
        {
        }
        public override bool Dye(Mobile from, DyeTub sender)
        {
            from.SendLocalizedMessage(sender.FailMessage);
            return false;
        }

        public override bool Scissor(Mobile from, Scissors scissors)
        {
            from.SendLocalizedMessage(502440); // Scissors can not be used on that to produce anything.
            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt(0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}