#pragma strict
	private var speed : int;
	private var friction : float;
	private var lerpSpeed : float;
	private var xDeg : float;
	private var yDeg : float;
	private var fromRotation : Quaternion;
	private var toRotation : Quaternion;
	
function Start () {
	
}
function Update () {
		if(Input.GetMouseButton(0)) {
         xDeg -= Input.GetAxis("Mouse X") * speed * friction;
         yDeg += Input.GetAxis("Mouse Y") * speed * friction;
         fromRotation = transform.rotation;
         toRotation = Quaternion.Euler(yDeg,xDeg,0);
         transform.rotation = Quaternion.Lerp(fromRotation,toRotation,Time.deltaTime  * lerpSpeed);
         }
}