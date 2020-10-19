import React, { useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Cadastrar Login/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import { ToastContainer, toast } from "react-toastify";
import 'react-toastify/dist/ReactToastify.css';


export default function CadastrarLogin(props){
    const [infos, setInfos] = useState(props.location.state);

    return(
        <div>
            <div className="cabecalho">
                <div>
                    <Link className="hihi" to="/" ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>
                <div className="barraPesquisa"></div>
                <div className="meio"></div>
            </div>

            <div className="ku">

                <div className="teco">Cadastrar</div>

                <input className="koko" type="text" placeholder="Nome Completo"></input>
                <input className="koko" type="text" placeholder="Email"></input>
                <input className="koko" type="text" placeholder="Username"></input>
                <input className="koko" type="password" placeholder="Senha"></input>
                <input className="koko" type="password" placeholder="Confirmar senha"></input>
                <div className="b"> Data de Nascimento</div>
                <input className="kaka" type="date"></input>
                <select className="kuku">
                    <option value="Selecione">Gênero</option>
                    <option value="Selecione">Masculino</option>
                    <option value="Selecione">Feminino</option>
                    <option value="Selecione">Não Binário</option>
                </select>
                <input className="koko" type="text" placeholder="CPF"></input>
                <input className="koko" type="text" placeholder="RG"></input>
                <input className="koko" type="text" placeholder="Número de celular"></input>
                <select className="keliki">
                    <option value="Selecione">Estado</option>
                    <option value="Selecione">Acre</option>
                    <option value="Selecione">Alagoas</option>
                    <option value="Selecione">Amapá</option>
                    <option value="Selecione">Amazonas</option>
                    <option value="Selecione">Bahia</option>
                    <option value="Selecione">Ceará</option>
                    <option value="Selecione">Distrito Federal</option>
                    <option value="Selecione">Espírito Santo</option>
                    <option value="Selecione">Goiás</option>
                    <option value="Selecione">Maranhão</option>
                    <option value="Selecione">Mato Grosso</option>
                    <option value="Selecione">Mato Grosso do Sul</option>
                    <option value="Selecione">Minas Gerais</option>
                    <option value="Selecione">Pará</option>
                    <option value="Selecione">Paraíba</option>
                    <option value="Selecione">Paraná</option>
                    <option value="Selecione">Pernambuco</option>
                    <option value="Selecione">Piauí</option>
                    <option value="Selecione">Rio de Janeiro</option>
                    <option value="Selecione">Rio Grande do Norte</option>
                    <option value="Selecione">Rio Grande do Sul</option>
                    <option value="Selecione">Rondônia</option>
                    <option value="Selecione">Roraima</option>
                    <option value="Selecione">Santa Catarina</option>
                    <option value="Selecione">São Paulo</option>
                    <option value="Selecione">Sergipe</option>
                    <option value="Selecione">Tocantins</option>
                </select>
                <input className="koko" type="text" placeholder="Cidade"></input>
                <div className="ki">
                    <input className="kruso" type="text" placeholder="CEP"></input>
                    <input className="kverna" type="text" placeholder="Bairro"></input>
                    <input className="kdete" type="number" placeholder="N°"></input>
                </div>
                <input className="koko" type="text" placeholder="Endereço"></input>
                <input className="koko" type="text" placeholder="Complemento"></input>

                <div className="ka">
                    <input className="ktia" type="checkbox"></input>
                    <h5>Li e concordo com os termos de uso</h5>
                </div>

                <button className="botox">Cadastrar</button>
            </div>

            <div className="rodape">
                <div className="tey">
                    <h5>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h5>
                </div>
            </div>
        </div>
    )
}