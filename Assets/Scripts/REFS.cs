using UnityEngine;

public class REFS : MonoBehaviour
{
   public static REFS instance; 

   public static ThrowDie THROW_DIE_SCRIPT;
   public ThrowDie throw_die_script;
   public static UIManager UI_MANAGER;
   public UIManager ui_manager;

   public static Canvas MAIN_CANVAS;
   public Canvas main_canvas;
   public static Transform DICE_PANEL;
   public Transform dice_panel;
   
   public static Transform DICE_HOLDER_GHOST;
   public Transform dice_holder_ghost;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        MAIN_CANVAS = main_canvas;
        DICE_PANEL = dice_panel;
        THROW_DIE_SCRIPT = throw_die_script;
        DICE_HOLDER_GHOST = dice_holder_ghost;
        UI_MANAGER = ui_manager;

    }

   

   
}
