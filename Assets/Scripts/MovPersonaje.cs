using UnityEngine;
using System.Collections;

public class MovPersonaje : MonoBehaviour {

	float speed = 0.3f;
	float sensitivity = 2.0f;

	public static bool locked = false;

	//float spacing = 1.0f;
	//Vector3 pos;
	
	void Update() {
		if (!Global.camMoving) {
			if (Input.GetKey(KeyCode.W) && CanMoveTowardsDirection(this.transform.parent.gameObject, this.transform.parent.forward, sensitivity))
				this.transform.parent.position += new Vector3(this.transform.parent.transform.forward.x * speed, 0, this.transform.parent.transform.forward.z * speed);
			if (Input.GetKey(KeyCode.S) && CanMoveTowardsDirection(this.transform.parent.gameObject, -this.transform.parent.forward, sensitivity))
				this.transform.parent.position -= new Vector3(this.transform.parent.transform.forward.x * speed, 0, this.transform.parent.transform.forward.z * speed);
			if (Input.GetKey(KeyCode.A) && CanMoveTowardsDirection(this.transform.parent.gameObject, -this.transform.parent.right, sensitivity))
				this.transform.parent.position -= new Vector3(this.transform.parent.transform.right.x * speed, 0, this.transform.parent.transform.right.z * speed);
			if (Input.GetKey(KeyCode.D) && CanMoveTowardsDirection(this.transform.parent.gameObject, this.transform.parent.right, sensitivity))
				this.transform.parent.position += new Vector3(this.transform.parent.transform.right.x * speed, 0, this.transform.parent.transform.right.z * speed);
			this.transform.localPosition = Vector3.zero;
		}
	}

	private bool CanMoveTowardsDirection(GameObject go, Vector3 dir, float sensitivity) {
		RaycastHit hit;
		Debug.DrawRay (go.transform.position, dir);
		if (Physics.Raycast (this.transform.position, dir, out hit, sensitivity)) {
			Debug.Log ("Sorry, you can't move there");
			return false;
		}
		else
			return true;
	}
}
	/* Motivos por los que no deberia existir este script:
	 * 1. El juego esta basado en otro que NO tiene este tipo de moviemiento.
	 * 2. El juego NO esta pensado para tener este tipode movimiento.
	 * 3. En la prrimera entrega el movimiento original existia, y era el utilizado.
	 * 4. Al no haber ningun comentario/critica sobre el mismo, procedimos a:
	 * 4.A. Dedicar tiempo a mejorar y agregar una animacion al movimiento
	 * 4.B. MEJORAR el movimiento
	 * 4.C. Agregar y reubicar muchas de las posiciones
	 * 4.D. NO pensar una dinamica de movimiento nueva
 	 * 4.E. NO pensar una dimamica de juego nueva
	 */