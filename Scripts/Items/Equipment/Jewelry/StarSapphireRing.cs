using System;

namespace Server.Items
{
    public class StarSapphireRing : GoldRing
    {
        [Constructable]
        public StarSapphireRing()
            : base()
        {
            this.Weight = 1.0;
			
            BaseRunicTool.ApplyAttributesTo(this, Utility.RandomMinMax(1, 4), 5, 100);
			
            if (Utility.Random(100) < 10)
                this.Attributes.RegenMana += 2;
            else
                this.Resistances.Cold += 10;		
        }

        public StarSapphireRing(Serial serial)
            : base(serial)
        {
        }

        //public override int LabelNumber
        //{
        //    get
        //   {
        //        return 1073455;
         //   }
        //}// dark sapphire bracelet
        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}