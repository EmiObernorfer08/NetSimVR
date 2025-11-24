using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Router_config : MonoBehaviour
{


    public TextMeshProUGUI router_config_IP;
    public TextMeshProUGUI router_config_hostname;

    public void IP_Config()
    {
        router_config_IP.text = "Der Befehl dafür wäre: ip address ...IP... ...SUBNETMASK...\nIP-Adresse: 172.16.1.32 255.255.255.0";
       
    }

    public void Hostname_Config()
    {
        router_config_hostname.text = "Der Befehl dafür wäre: hostname ...NAME...\nHostname: hostname Router_01";
    }


}
