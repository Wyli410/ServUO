//Created by Hotshot aka Mule II

using System;
using Server.Engines.CannedEvil;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;
using Server.Regions;
using System.Linq;
using System.Collections; // needed for ArrayList
using System.Collections.Generic;
				
namespace Server.Mobiles
{
    [CorpseName("Corpse Of The Keeper")]
    public class KeeperOfTheSkillMount : BaseChampion
    {
        public override bool ShowFameTitle { get { return false; } }

        [Constructable]
        public KeeperOfTheSkillMount() : base(AIType.AI_Melee)
        {
            Name = "Keeper Of The Skill Mount";

            Body = 400;
            Hue = 19999;
            BaseSoundID = 1072;

            SetStr(400, 800);
            SetDex(500, 500);
            SetInt(200, 250);

            SetHits(5000, 5000);

            SetDamage(100, 200);

            SetDamageType(ResistanceType.Physical, 70);
            SetDamageType(ResistanceType.Cold, 70);
            SetDamageType(ResistanceType.Fire, 70);

            SetResistance(ResistanceType.Physical, 50, 100);
            SetResistance(ResistanceType.Energy, 50, 100);
            SetResistance(ResistanceType.Poison, 50, 100);
            SetResistance(ResistanceType.Cold, 50, 100);
            SetResistance(ResistanceType.Fire, 50, 100);

            SetSkill(SkillName.Wrestling, 95.1, 100.0);
            SetSkill(SkillName.Magery, 70.1, 100.0);
            SetSkill(SkillName.Anatomy, 95.1, 100.0);
            SetSkill(SkillName.MagicResist, 95.1, 100.0);
            SetSkill(SkillName.Swords, 95.1, 100.0);
            SetSkill(SkillName.Tactics, 95.1, 100.0);
            SetSkill(SkillName.Parry, 95.1, 100.0);
            SetSkill(SkillName.Focus, 95.1, 100.0);

            Fame = 25000;
            Karma = -25000;

            VirtualArmor = 40;


            AddItem(new HoodedShroudOfShadows(19999));

            PackGold(1400, 1600);

            Item hair = new Item(Utility.RandomList(8265));
            hair.Hue = 1153;
            hair.Layer = Layer.Hair;
            hair.Movable = false;
            AddItem(hair);
        }

        public override void OnDeath(Container c)
        {

            switch (Utility.Random(300))
            {
                case 0: c.DropItem(new SkillMount()); break;
                case 1: c.DropItem(new SkillMountBeetle()); break;
                case 2: c.DropItem(new SkillMountHorse()); break;
                case 3: c.DropItem(new SkillMountKirin()); break;
                case 4: c.DropItem(new SkillMountLlama()); break;
                case 5: c.DropItem(new SkillMountOstard()); break;
                case 6: c.DropItem(new SkillMountRidgeback()); break;
                case 7: c.DropItem(new SkillMountSwampDragon()); break;
                case 8: c.DropItem(new SkillMountUnicorn()); break;
                    //case 9: c.DropItem( new SkillMountDemon( ) ); break;
                    //case 10: c.DropItem( new SkillMountPolarB( ) ); break;
                    //case 11: c.DropItem( new SkillMountCuShide( ) ); break;
            }

            //switch ( Utility.Random( 500 ) )
            {
                //case 0: c.DropItem( new SkillMountChimera( ) ); break; 
            }
            base.OnDeath(c);

        }

        public override bool AlwaysAttackable { get { return true; } }


        public override void GenerateLoot()
        {
            AddLoot(LootPack.UltraRich, 6);
        }
        public static void GiveScrollTo(Mobile killer, SpecialScroll scroll)
        {
            if (scroll == null || killer == null)	//sanity
                return;
            killer.SendLocalizedMessage(1049524); // You have received a scroll of power!

            if (killer.Alive)
                killer.AddToBackpack(scroll);
            else
            {
                if (killer.Corpse != null && !killer.Corpse.Deleted)
                    killer.Corpse.DropItem(scroll);
                else
                    killer.AddToBackpack(scroll);
            }
            PlayerMobile pm = (PlayerMobile)killer;
            PowerScroll PS = PowerScroll.CreateRandomNoCraft(5, 20);
            GiveScrollTo(pm, (SpecialScroll)PS);
        }
            
        public KeeperOfTheSkillMount( Serial serial ) : base( serial )
		{
		}


        public override ChampionSkullType SkullType
        {
            get
                {
                  return (ChampionSkullType) Utility.Random(Enum.GetNames(typeof(ChampionSkullType)).Length);
                }   
        }

public override Type[] UniqueList
        {
            get
            {
                return new Type[] { typeof(FangOfRactus) };
            }
        }
        public override Type[] SharedList
        {
            get
            {
                return new Type[]
                {
                    typeof(CrownOfTalKeesh),
                    typeof(ShroudOfDeceit),
                    typeof(EmbroideredOakLeafCloak),
                    typeof(DjinnisRing),
                    typeof(DetectiveBoots),
                    typeof(GauntletsOfAnger)
                };
            }
        }
        public override Type[] DecorativeList
        {
            get
            {
                return new Type[] { typeof(SwampTile), typeof(MonsterStatuette) };
            }
        }
        public override MonsterStatuetteType[] StatueTypes
        {
            get
            {
                return new MonsterStatuetteType[] { MonsterStatuetteType.Slime };
            }
        }

        public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
			
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
      
		}
	}
}