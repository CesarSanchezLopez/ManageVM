import { Component, OnInit } from '@angular/core';
import { VmService } from 'src/app/services/vm.service';
import { Vm } from 'src/app/models/vm.model';

@Component({
  selector: 'app-vms',
  templateUrl: './vms.component.html'
})
export class VmsComponent implements OnInit {
  vms: Vm[] = [];
  selectedVM: Vm = this.emptyVm();
  editing = false;
  errorMessage: string = '';

  constructor(private vmService: VmService) {}

  ngOnInit(): void {
    this.loadVMs();
  }

  loadVMs() {
    this.vmService.getAll().subscribe({
      next: (data) => {
        this.vms = data;
        this.errorMessage = '';
      },
      error: (err) => {
        this.errorMessage = err.message;
        console.error('Error al cargar VMs:', err);
      }
    });
  }
  newVM() {
    this.selectedVM = this.emptyVm();
    this.editing = true;
  }

  editVM(vm: Vm) {
    this.selectedVM = { ...vm };
    this.editing = true;
  }

  saveVM() {
    if (this.selectedVM.id) {
      this.vmService.update(this.selectedVM.id, this.selectedVM).subscribe({
        next: () => {
          this.loadVMs();
          this.cancel();
          this.errorMessage = '';
        },
        error: (err) => {
          this.errorMessage = err.message;
          console.error('Error al actualizar VM:', err);
        }
      });
    } else {
      this.vmService.create(this.selectedVM).subscribe({
        next: () => {
          this.loadVMs();
          this.cancel();
          this.errorMessage = '';
        },
        error: (err) => {
          this.errorMessage = err.message;
          console.error('Error al crear VM:', err);
        }
      });
    }
  }

  deleteVM(id: number) {
    if (confirm('¿Eliminar esta máquina virtual?')) {
      this.vmService.delete(id).subscribe({
        next: () => {
          this.loadVMs();
          this.errorMessage = '';
        },
        error: (err) => {
          this.errorMessage = err.message;
          console.error('Error al eliminar VM:', err);
        }
      });
    }
  }
  

  cancel() {
    this.editing = false;
    this.selectedVM = this.emptyVm();
  }

  emptyVm(): Vm {
    return {
      id: 0,
      name: '',
      cores: 1,
      ram: 1,
      disk: 10,
      operatingSystem: '',
      status: 'Stopped',
      createdAt: new Date().toISOString(),  // Establecer fecha actual en formato ISO
      updatedAt: new Date().toISOString(),
      ownerId: 0

    };
  }
}