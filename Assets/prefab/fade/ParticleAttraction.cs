using UnityEngine;
using System.Collections;

[RequireComponent(typeof(ParticleSystem))]
public class ParticleAttraction : MonoBehaviour
{
    public GameObject Particle_mesh;

    public Transform Target;
    public Vector3 particleresize;
    public float speed =2.0f;
    public bool Particle_emi;


    ParticleSystem System_;
    ParticleSystem.EmissionModule particle_emi;
    ParticleSystem.ShapeModule mesh;
    ParticleSystem.Particle[] particles = new ParticleSystem.Particle[2000];

    void Start()
    {
        //mesh_obj = transform.root.gameObject.GetComponent<MeshFilter>().mesh;
        mesh = GetComponent<ParticleSystem>().shape;
        if (Particle_mesh == null) Debug.Log(transform.root.gameObject.name + "Particle_mesh Null");
        mesh.mesh = Particle_mesh.GetComponent<MeshFilter>().mesh;
        mesh.scale = Particle_mesh.GetComponent<Transform>().localScale - new Vector3(0.1f, 0.1f, 0.1f);
        particle_emi = gameObject.GetComponent<ParticleSystem>().emission;
    }

    void Update()
    {

        if (System_ == null)
        {
            System_ = GetComponent<ParticleSystem>();
        }

        int count = gameObject.GetComponent<ParticleSystem>().GetParticles(particles);

        for (int i = 0; i < count; i++)
        {
            ParticleSystem.Particle particle = particles[i];

            float distance = Vector3.Distance(particle.position, Target.position);

            Vector3 particle_pos = System_.transform.TransformPoint(particle.position);
            Vector3 Target_pos = Target.position;

            float LifeTime = speed - (particle.remainingLifetime / particle.startLifetime);

            Vector3 dist = System_.transform.InverseTransformPoint(Vector3.Lerp(particle_pos, Target_pos, LifeTime));
            particle.position = dist;
            particles[i] = particle;
        }

        System_.SetParticles(particles, count);
        if (Particle_emi) particle_emi.enabled = false;
        else particle_emi.enabled = true;
    }
}