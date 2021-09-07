using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalMover : IVerticalMover
{
    IEntityController _entityController;
    Rigidbody rb;
    public VerticalMover(IEntityController entityController)
    {
        _entityController = entityController;
        rb = entityController.rb;
    }
    public void Active(float speed)
    {
        rb.velocity=(Vector3.forward * speed * Time.deltaTime * 10);
    }
}
