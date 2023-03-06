using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint missileLauncher;
    public TurretBlueprint laserBeamer;

    public GameObject ui1;
    public GameObject ui2;
    public GameObject ui3;

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void SelectStandardTurret()
    {
        ui1.SetActive(false);
        ui2.SetActive(true);
        ui3.SetActive(true);

        buildManager.SelectTurretToBuild(standardTurret);
    }

    public void SelectMissileLauncher()
    {
        ui1.SetActive(true);
        ui2.SetActive(false);
        ui3.SetActive(true);
        buildManager.SelectTurretToBuild(missileLauncher);
    }

    public void SelectLaserBeamer()
    {
        ui1.SetActive(true);
        ui2.SetActive(true);
        ui3.SetActive(false);
        buildManager.SelectTurretToBuild(laserBeamer);
    }

}
