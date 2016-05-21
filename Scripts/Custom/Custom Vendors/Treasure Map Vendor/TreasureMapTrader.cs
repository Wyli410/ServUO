using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;

namespace Server.Mobiles
{[CorpseName( "Noah's Corpse" )]public class Noah : Mobile{public virtual bool IsInvulnerable{ get{ return true; } }
[Constructable]public Noah(){
//////////////////////////////name
Name = "Noah";
/////////////////////////////////title
Title = "The Pirate";
////////sex
Body = 0x190;
//////skincolor
Hue = 0x840F;
////////haircolor
int hairHue = 0x478;
////////clothing and other apperance
AddItem( new LongHair( hairHue ) );
AddItem( new Server.Items.TricorneHat( 1230 ) );AddItem( new Server.Items.LongPants( 118 ) );AddItem( new Server.Items.Boots() );AddItem( new Server.Items.FormalShirt( 1230 ) );AddItem( new Server.Items.Cloak( 117 ) );Blessed = true;CantWalk = true;}
public Noah( Serial serial ) : base( serial ){}
public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
{ base.GetContextMenuEntries( from, list ); list.Add( new NoahEntry( from, this ) ); } 
public override void Serialize( GenericWriter writer ){base.Serialize( writer );writer.Write( (int) 0 );}
public override void Deserialize( GenericReader reader ){base.Deserialize( reader );int version = reader.ReadInt();}
public class NoahEntry : ContextMenuEntry{private Mobile m_Mobile;private Mobile m_Giver;
public NoahEntry( Mobile from, Mobile giver ) : base( 6146, 3 ){m_Mobile = from;m_Giver = giver;}
public override void OnClick(){if( !( m_Mobile is PlayerMobile ) )return;
PlayerMobile mobile = (PlayerMobile) m_Mobile;{
///////////////////////////////////////////////// gumpname
    if (!mobile.HasGump(typeof(TMapGump11)))
    {
mobile.SendGump( new TMapGump11( mobile ));}}}
}
public override bool OnDragDrop( Mobile from, Item dropped ){               Mobile m = from;PlayerMobile mobile = m as PlayerMobile;
if ( mobile != null){
/////////////////////////////////////////////////////////// item to be dropped
if (dropped is TreasureMap)
  {
    if (dropped.Amount != 1)
  { this.PrivateOverheadMessage(MessageType.Regular, 1153, false, "There's not the right amount here!", mobile.NetState); return false; }
  dropped.Delete();
///////////////the reward
int level = Utility.Random(4, 8);
mobile.AddToBackpack(new TreasureMap(level, Map.Internal));
 // mobile.AddToBackpack( new Gold( 0 ) );
// mobile.AddToBackpack( new MasterCoin( 10 ) );
////////////////////////////////////////////////////////// thanksmessage
this.PrivateOverheadMessage( MessageType.Regular, 1153, false, "Arr, I Thank Ye for Thy Buisness. Come back another time!", mobile.NetState );
return true;}else if ( dropped is Whip){this.PrivateOverheadMessage( MessageType.Regular, 1153, 1054071, mobile.NetState );return false;}else{this.PrivateOverheadMessage( MessageType.Regular, 1153, false,"I have no need for this...", mobile.NetState );}}return false;}}}
