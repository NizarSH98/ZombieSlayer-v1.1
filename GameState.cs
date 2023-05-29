using SkeletonSlayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSlayer
{
    internal class GameState
    {
        public GameState() { }
        

        public int mage_walk_counter { get; set; }
        public int mage_run_counter { get; set; }
        public int mage_atk_counter { get; set; }
        public int mage_die_counter { get; set; }
        public int HP_counter { get; set; }
        
        public int mage_step { get; set; }
        public int screen_w { get; set; }
        public int screen_h { get; set; }
        public int mage_x { get; set; }
        public int mage_y { get; set; }
        public int mage_h { get; set; }
        public int mage_w { get; set; }

        public bool Main_Menu { get; set; }
        public int main_counter { get; set; }

        public bool Arcade { get; set; }

        public bool Survival { get; set; }
        public Random rx { get; set; }
        public int[] Health { get; set; }
        public int map_x { get; set; }
        public int map_y { get; set; }
        public int map_w { get; set; }
        public int map_h { get; set; }
        public int mapI { get; set; }
        public int rc { get; set; }
        public int Z_x { get; set; }
        public int Z_y { get; set; }
        public int S_x { get; set; }
        public int S_y { get; set; }
        public int P_X { get; set; }
        public int P_Y { get; set; }
        public int P_W { get; set; }
        public int P_H { get; set; }
        public int GO_X { get; set; }
        public int GO_Y { get; set; }
        public int GO_W { get; set; }
        public int GO_H { get; set; }
        public int No_X { get; set; }
        public int Yes_X { get; set; }
        public int YesNo_Y { get; set; }
        public int YesNo_W { get; set; }
        public int YesNo_H { get; set; }
        public int shottype { get; set; }
        public bool completed { get; set; }
        public bool restart { get; set; }
        public int potion_count { get; set; }
        public int sheild_counter { get; set; }
        public int sheild_Time { get; set; }
        public int HP1_X { get; set; }
        public int HP2_X { get; set; }
        public int HP1_Y { get; set; }
        public int HP2_Y { get; set; }
        public int HP3_X { get; set; }
        public int HP3_Y { get; set; }
        public int sheild_x { get; set; }
        public int sheild_y { get; set; }
        public int sheild2_x { get; set; }
        public int sheild2_y { get; set; }
        public int zombies_1_dead { get; set; }
        public int zombies_2_dead { get; set; }
        public int skeletons_dead { get; set; }
        public int health_counter_i { get; set; }
        public int esc_counter { get; set; }
        public int sheild_count { get; set; }
        public Random r { get; set; }
        public bool moveup { get; set; }
        public bool movedown { get; set; }
        public bool moveleft { get; set; }
        public bool moveright { get; set; }
        public bool mage_die { get; set; }
        public bool L { get; set; }
        public bool R { get; set; }
        public bool run { get; set; }
        public bool attack { get; set; }
        public bool DR { get; set; }
        public bool Dl { get; set; }
        public bool health_counted { get; set; }
        public bool pause { get; set; }
        public bool LEVEL1 { get; set; }
        public bool LEVEL2 { get; set; }
        public bool BOSS_LEVEL { get; set; }
        public bool new_map_1 { get; set; }
        public bool new_map_2 { get; set; }
        public bool sh { get; set; }
        public bool mouse_over_yes { get; set; }
        public bool mouse_over_no { get; set; }
        public bool mouse_over_rst { get; set; }
        public bool mouse_over_ext { get; set; }
        public bool completed_2 { get; set; }
        Zombie[] zombies_1 { get; set; }
        Zombie[] zombies_2 { get; set; }
        Skeleton[] skeletons { get; set; }
        Zombie zombie { get; set; }
        Healing_Potion HP_1 { get; set; }
        Healing_Potion HP_2 { get; set; }
        Healing_Potion HP_3 { get; set; }
        public int zombie1_counter { get; set; }
        public int zombie2_counter { get; set; }
        public int skeleton_counter { get; set; }
        Sheild sheild { get; set; }
        Sheild sheild2 { get; set; }
        public int zombie1_time_counter { get; set; }
        public int zombie2_time_counter { get; set; }
        public int init_zombie1_time_counter { get; set; }
        public int init_zombie2_time_counter { get; set; }
        public int skeleton_time_counter { get; set; }
        public int init_skeleton_time_counter { get; set; }
        public int health_counter { get; set; }
        public int i { get; set; }
        public int lvl_1_time { get; set; }
        public bool lvl_1_draw { get; set; }
        public int lvl_2_time { get; set; }
        public bool lvl_2_draw { get; set; }
        public int boss_lvl_time { get; set; }
        public bool boss_lvl_draw { get; set; }
        fireshot[] F { get; set; }
        Zombie[] zombies { get; set; }
        Skeleton[] skeletonss { get; set; }
        fireshot[] Fs { get; set; }
        public int shotx { get; set; }
        public int shoty { get; set; }
        public int shotcounter { get; set; }
        public int B_X { get; set; }
        public int B_Y { get; set; }
        public int boss_timer { get; set; }
        public int boss_hit { get; set; }
        public bool game_won { get; set; }
        public int title_counter { get; set; }
        public int survival { get; set; }
    }
}
