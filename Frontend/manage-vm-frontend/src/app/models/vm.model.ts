export interface Vm {
id: number;
name: string;
cores: number;
ram: number;
disk: number;
operatingSystem: string;
status: string;
createdAt?: string;
updatedAt?: string;
ownerId: number;
}